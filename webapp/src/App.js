
function MainImage({ img_src }) {
    return (
        <img src={img_src}/>
    );
}

export default function MainWindow({ img_src }) {
    return (
        <div id="main-window">
            <MainImage img_src={img_src}/>
        </div>
    );
}