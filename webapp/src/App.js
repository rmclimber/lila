import { useState } from "react";


function MainImage({ img_src }) {
    return (
        <>
            <img src={img_src}/>
            Image here
        </>
    );
}

export default function MainWindow({ img_src }) {
    return (
        <div id="main-window">
            <MainImage img_src={img_src}/>
        </div>
    );
}