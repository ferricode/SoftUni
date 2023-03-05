import Footer from './components/Footer';
import Header from './components/Header';
import RssFeed from './components/RssFeed';
import * as Parser from 'rss-parser';
import { useEffect, useState } from 'react';


function App() {

  const [feeds, setFeed] = useState({});

  var parser = new Parser();
  const CORS_PROXY = "https://cors-anywhere.herokuapp.com/";

  useEffect(() => {
    parser.parseURL(CORS_PROXY + 'https://www.reddit.com/.rss')
      .then(feed => {
        setFeed(feed);
      });
  }, []);
  console.log(feeds.title);
  return (
    <div>
      <Header />
      <RssFeed feeds={feeds} />
      <Footer />
    </div>
  );
};

export default App;
