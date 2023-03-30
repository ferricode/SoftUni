import { memo } from 'react';
import { Link } from 'react-router-dom';

const LatestGame = ({
    _id,
    imageUrl,
    title,
    rating,
    onLikeClick
}) => {
    let stars = [];
    for (let i = 0; i < rating; i++) {
        stars.push(<span>☆</span>);
    }
    return (
        <div className="game">
            <div className="image-wrap">
                <img alt={title} src={imageUrl} />
            </div>
            <h3>{title}</h3>
            <div className="rating">
                {stars}
            </div>
            <div className="data-buttons">
                <Link to={`catalog/${_id}`} className="btn details-btn">Details</Link>
                <button className="btn details-btn" onClick={() => onLikeClick(_id)}>Like</button>
            </div>
        </div>
    );
};
export default memo(LatestGame);