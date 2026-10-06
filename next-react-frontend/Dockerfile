# syntax=docker/dockerfile:1

# ============================================
# Stage 1: Dependencies
# ============================================
ARG NODE_VERSION=24.16.0
ARG PNPM_VERSION=12.9.1

FROM node:${NODE_VERSION}-alpine AS deps
WORKDIR /usr/src/app

RUN --mount=type=cache,target=/root/.npm \
    npm install -g pnpm@${PNPM_VERSION}

# Nur die Lockfiles kopieren für besseres Caching
COPY package.json pnpm-lock.yaml pnpm-workspace.yaml ./
COPY prisma ./prisma
COPY prisma.config.ts ./

# Dependencies installieren (inkl. devDependencies für den Build)
RUN --mount=type=cache,target=/root/.local/share/pnpm/store \
    pnpm install --frozen-lockfile --ignore-scripts

# ============================================
# Stage 2: Build
# ============================================
FROM node:${NODE_VERSION}-alpine AS builder
WORKDIR /usr/src/app

RUN --mount=type=cache,target=/root/.npm \
    npm install -g pnpm@${PNPM_VERSION}

COPY --from=deps /usr/src/app/node_modules ./node_modules
COPY . .

# Prisma Client generieren
ENV DATABASE_URL="postgresql://user:pass@localhost:5432/db"
RUN pnpm exec prisma generate

# Next.js Produktions-Build erstellen
ENV NEXT_TELEMETRY_DISABLED=1
RUN pnpm build

# ============================================
# Stage 3: Production Runner
# ============================================
FROM node:${NODE_VERSION}-alpine AS runner
WORKDIR /usr/src/app

ENV NODE_ENV=production
ENV NEXT_TELEMETRY_DISABLED=1
# Deaktiviert pnpms automatische Prüfung vor jedem Start
ENV CI=true
ENV PNPM_CONFIG_VERIFY_DEPS_BEFORE_RUN=false

RUN addgroup --system --gid 1001 nodejs && \
    adduser --system --uid 1001 nextjs

# Standalone-Output kopieren (enthält bereits alle nötigen node_modules)
COPY --from=builder --chown=nextjs:nodejs /usr/src/app/.next/standalone ./
# Statische Dateien kopieren
COPY --from=builder --chown=nextjs:nodejs /usr/src/app/.next/static ./.next/static
# Public-Ordner kopieren (falls vorhanden)
COPY --from=builder --chown=nextjs:nodejs /usr/src/app/public ./public
# Prisma-Schema und generierter Client für Runtime-Zugriff
COPY --from=builder --chown=nextjs:nodejs /usr/src/app/prisma ./prisma

USER nextjs

EXPOSE 3000
ENV PORT=3000
ENV HOSTNAME="0.0.0.0"

# Standalone-Server direkt starten (nicht "pnpm start")
CMD ["node", "server.js"]