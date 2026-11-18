//root/components/dataImage.tsx

'use client'

import {useState} from "react";

export default function DataImage() {

    const [file, setFile] = useState<File | null>(null);
    const [status, setStatus] = useState('');

    const onUpload = async () => {

        if (!file) { return setStatus('Bitte wähle eine Datei aus.'); }

        // FormData ist ein eingebautes (Web-API) Browser-Objekt.
        const formData = new FormData();
        formData.append('file', file);
        
        setStatus('Lädt hoch...')

        try {
            const res = await fetch('/api/upload', {
                method: 'POST',
                body: formData,
            });

        setStatus(res.ok ? 'Upload erfolgreich!' : `Fehler: ${res.statusText}`);
        } catch (error) {
            setStatus(`Fehler: ${error}`);
        }
        
    }

    return (
        <>
            <h2 className="">
                Hello dataImage
            </h2>

            <div className="mt-4">

                <input  type="file" 
                        accept="image/*"
                        onChange={(e) => setFile(e.target.files?.[0] ?? null) } 
                />

                <button className="ml-2" onClick={onUpload} >
                    Hochladen
                </button>

                <p>{status}</p>
            </div>
        </>
    )
}