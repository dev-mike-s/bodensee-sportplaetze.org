
import {NextRequest, NextResponse} from "next/server";

export async function POST(req: NextRequest) {

    const formData = await req.formData();

    const file = formData.get('file') as File | null;

    if (!file) { return NextResponse.json({error: 'Keine Datei hochgeladen.'}, {status:400});}

    //Weiterleiten an die .NET API
    const forward = new FormData();
    forward.append('file', file, file.name);

    try {
        const res = await fetch('http://localhost:5000/api/images/upload', {
            method: 'POST',
            body: forward,
        });
    
        if (!res.ok) {
            return NextResponse.json({error: `Fehler beim Hochladen: ${res.statusText}`}, {status: res.status});
        }
        }
    catch (error) {
    }

}