using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.RePlay
{
    public class RePlayer : IRePlayer
    {
        // private Dictionary<string, Track> rePlayerTracks = new Dictionary<string, Track>();
        private List<Track> rePlayer = new List<Track>();
        private Queue<Track> listeningTracks = new Queue<Track>();
        private Dictionary<string, List<Track>> artistAlbums = new Dictionary<string, List<Track>>();
        private Dictionary<string, List<Track>> albumNameTracks = new Dictionary<string, List<Track>>();

        public int Count => rePlayer.Count;

        public void AddToQueue(string trackName, string albumName)
        {
            Track trackToQueue = (Track)rePlayer.Where(t => t.Title == trackName);

            if (!albumNameTracks.Keys.Contains(albumName) || trackToQueue == null)
            {
                throw new ArgumentException();
            }

            listeningTracks.Enqueue(trackToQueue);

        }

        public void AddTrack(Track track, string album)
        {
            rePlayer.Add(track);
            if (!albumNameTracks.ContainsKey(album))
            {
                albumNameTracks[album] = new List<Track>();
            }
            if (!artistAlbums.ContainsKey(track.Artist))
            {
                artistAlbums[track.Artist] = new List<Track>();
            }
            artistAlbums[track.Artist].Add(track);
            albumNameTracks[album].Add(track);
        }

        public bool Contains(Track track)
        {
            return rePlayer.Contains(track);
        }

        public IEnumerable<Track> GetAlbum(string albumName)
        {
            if (!albumNameTracks.ContainsKey(albumName))
            {
                throw new ArgumentException();
            }
            return albumNameTracks[albumName].OrderByDescending(a => a.Plays);
        }

        public Dictionary<string, List<Track>> GetDiscography(string artistName)
        {
            throw new NotImplementedException(); 


        }

        public Track GetTrack(string title, string albumName)
        {
            Track trackToGet = albumNameTracks[albumName].FirstOrDefault(t => t.Title == title);
            if (trackToGet == null)
            {
                throw new ArgumentException();
            }
            return trackToGet;
        }

        public IEnumerable<Track> GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(int lowerBound, int upperBound)
        {
           return  rePlayer
                .Where(t => lowerBound <= t.DurationInSeconds && t.DurationInSeconds >= upperBound)
                .OrderBy(t=>t.DurationInSeconds)
                .OrderByDescending(t=>t.Plays);
        }

        public IEnumerable<Track> GetTracksOrderedByAlbumNameThenByPlaysDescendingThenByDurationDescending()
        {
            albumNameTracks.OrderBy(kvp => kvp.Key);

            foreach (var item in albumNameTracks.Values)
            {
                item.OrderByDescending(t => t.Plays).ThenBy(t => t.DurationInSeconds);
            }
            return (IEnumerable<Track>)albumNameTracks.ToDictionary(k => k.Key, v => v.Value);
        }

        public Track Play()
        {
           Track toListen= listeningTracks.Dequeue();
            if (toListen==null)
            {
                throw new ArgumentException();
            }
            rePlayer.Remove(toListen);
            toListen.Plays++;
            rePlayer.Add(toListen);

            return toListen;
        }

        public void RemoveTrack(string trackTitle, string albumName)
        {
                    throw new NotImplementedException();

        }
    }
}
