using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class LinkRepository
    {
        private readonly string host = "http://link.cloudapp.net/";
        public List<LinkInfo> GetLinks()
        {
            using (var context = new MyDbEntities())
            {
                return context.Links.Select(x => new LinkInfo { Url = x.url, ShortUrl = host + x.shortened_url, Clicks = x.ClickInfoes.Count }).ToList();
            }
        }

        public LinkInfo GetLink(string key)
        {
            using (var context = new MyDbEntities())
            {
                return context.Links.Where(x => x.shortened_url == key).Select(x => new LinkInfo { Url = x.url, ShortUrl = host + x.shortened_url, Clicks = x.ClickInfoes.Count }).SingleOrDefault();
            }
        }

        public void AddClick(string key)
        {
            using (var context = new MyDbEntities())
            {
                var linkId = context.Links.Single(x => x.shortened_url == key).id;
                context.ClickInfoes.Add(new ClickInfo { link_id = linkId, clicked_date = DateTime.Now });
                context.SaveChanges();
            }
        }

        public LinkInfo SaveLink(string url)
        {
            var shortUrl = RandomString(6);
            var link = new Link { shortened_url = shortUrl, url = url };
            using (var context = new MyDbEntities())
            {
                context.Links.Add(link);
                context.SaveChanges();
            }

            return new LinkInfo {ShortUrl = host + link.shortened_url, Url = link.url, Clicks = 0};
        }


        private static readonly Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
