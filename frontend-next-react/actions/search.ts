    
    'use server'

    import {prisma} from "@/lib/prisma";

    /* Server Action for components/searchBar.tsx 'handleSearch':
     * With Prisma as ORM (Fullstack Next.js).
     */

    export type RawSportfield = {
        id: number;
        name: string | null;
        rating: number;
        address: {
            id: number;
            name: string | null;
            street: string | null;
            localityId: number;
            locality: {
                id: number;
                name: string;
                zipcode: number;
                localityType: string | null;
            };
        } | null;
        sportFieldType: {
            sportFieldId: number;
            sportTypeId: number;
            sportType: {
                id: number;
                name: string | null;
            }
        } [],
    };

    export async function handleSearch(city: string, sport: string) {

        let result: RawSportfield[] | null = null;

        console.log("LOG: Anfrage in actions angekommen!");

        if (!city && !sport) {
            return [];
        }

        try {
            result = await prisma.sportField.findMany({
                where: {
                    sportFieldType: {
                        some: {
                            sportType: {
                                name: sport
                            }
                        }
                    },
                    address: {
                        locality: {
                                name: city
                        },
                    }
                },

                include: {
                    address: {
                        include: {
                            locality: true
                        }
                    },
                    sportFieldType: {
                        include: {
                            sportType: true
                        }
                    }
                },

            });
            console.log("LOG: 'search.ts': ");
            console.log(result);

        } catch (error) {
            console.error("LOG: Fehler: " );
            console.error(error);
            return null;
        }

        return result!.map((r: RawSportfield) => ({
            id: r.id,
            name: r.name,
            rating: r.rating,
            city: r.address?.locality.name ?? "",
            street: r.address?.street ?? "",
            sports: r.sportFieldType.map(s => s.sportType.name ?? ""),
        }));
    }