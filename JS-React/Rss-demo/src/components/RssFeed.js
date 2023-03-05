import Feed from './Feed';


export default function RssFeed({ feeds }) {

    //     this.state = { feed: [] };
    // }

    //     async componentDidMount() {
    //     const feed = await parser.parseURL('https://www.reddit.com/.rss');
    //     this.setState({ feed });
    // }

    // render() {
    //     return (
    //         <div>
    //             <h1>RSS Feed</h1>
    //             this.state.feed.map((item, i) => (
    //             <div key={i}>
    //                 <h1>item.title</h1>
    //                 <a href="">item.link</a>
    //             </div>
    //             ))
    //         </div>
    //     );
    // }
    // };

    return (
        <div className="row me-row content-ct speaker" id="speakers">
            <h2 className="row-title">{feeds.title}</h2>
            {feeds && feeds.items ? feeds.items.map((item, i) => <Feed key={i} {...item} />) : ""}
        </div>

    );
}

