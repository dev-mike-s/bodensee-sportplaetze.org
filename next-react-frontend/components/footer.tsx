
export default function Footer() {

    return (
        <footer className="bg-gray-100 rounded-base border border-default">
            
            {/* layout container*/}
            <div className="w-full bg-green-600">
            
                {/* flex/content container*/}
                <div className="flex flew-row justify-between items-center">

                    {/* left side content */}
                    <div className="">
                        <p>Container Links</p>
                    </div>

                    {/* right side content */}
                    <div className="">
                        <p>Container rechts</p>

                    </div>
                </div>
            </div>
        </footer>
    );
};
