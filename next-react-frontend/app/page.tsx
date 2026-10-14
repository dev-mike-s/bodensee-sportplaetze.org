
'use client'

import SearchBar from "../components/searchBar";

export default function HomePage() {

    return (
        <main className="mt-10">

            <div className="text-center">

                <h1 className="mt-10">
                    Willkommen Hobbysportler / <br></br> Sportaktiver
                </h1>
                <h2 className="mt-5 w-2xl mx-auto">
                    Finde den passenden Sportplatz in deiner Nähe! (Jedoch nur innerhalb 
                    des See's der Bodenseeregion: Untersee, Überlingersee, Obersee) Und 
                    hilf uns die fehlenden Orte zu erschließen, durch eigene Einträge.
                </h2>

                <br></br>

                <div className="bg-stone-100 border-solid m-10">

                    <h3 className="mt-10 p-4">
                        Welchen Platz möchtest du finden?
                    </h3>

                    <SearchBar />
                </div>

            </div>
        </main>
    )
}