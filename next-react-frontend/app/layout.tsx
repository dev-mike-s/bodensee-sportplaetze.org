//root/app/layout.tsx

/**
 *
 */

// TypeScript may complain about side-effect CSS imports when no declarations are present.
// Suppress the error for this import since Next.js supports global CSS imports.
// @ts-ignore
import "./globals.css";
import type {Metadata} from "next";
import Navbar from '../components/navbar';
import Footer from '../components/footer';
import { Geist } from "next/font/google";
import { cn } from "@/lib/utils";

const geist = Geist({subsets:['latin'],variable:'--font-sans'});

export const metadata: Metadata = {
    title: "Bodensee Sportplaetze",
    description: "Finde und bewerte deinen Sportplatz. Konnekte dich mit Anderen.",
};

export default function RootLayout( {children}: {children: React.ReactNode;} )
{
    return (
        <html lang="de" className={cn("font-sans", geist.variable)}>
            <body>
                <Navbar />
                    {children}
                <Footer />
            </body>
        </html>
    );
}
