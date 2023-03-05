export default function Feed({
    title,
    link,
    content
}) {
    return (

        <div className="col-md-4 col-sm-12 feature">
            <h3>{title}</h3>
            <p>{content}</p>
            {/* <a href={link} target="_blank">{title}</a> */}
        </div>
    );
};