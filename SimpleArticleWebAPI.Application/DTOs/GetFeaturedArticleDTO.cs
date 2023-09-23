using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleArticleWebAPI.Application.DTOs
{

	// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
	public class Article
	{
		[JsonPropertyName("views")]
		public int views { get; set; }

		[JsonPropertyName("rank")]
		public int rank { get; set; }

		[JsonPropertyName("view_history")]
		public List<ViewHistory> view_history { get; set; }

		[JsonPropertyName("type")]
		public string type { get; set; }

		[JsonPropertyName("title")]
		public string title { get; set; }

		[JsonPropertyName("displaytitle")]
		public string displaytitle { get; set; }

		[JsonPropertyName("namespace")]
		public Namespace @namespace { get; set; }

		[JsonPropertyName("wikibase_item")]
		public string wikibase_item { get; set; }

		[JsonPropertyName("titles")]
		public Titles titles { get; set; }

		[JsonPropertyName("pageid")]
		public int pageid { get; set; }

		[JsonPropertyName("thumbnail")]
		public Thumbnail thumbnail { get; set; }

		[JsonPropertyName("originalimage")]
		public Originalimage originalimage { get; set; }

		[JsonPropertyName("lang")]
		public string lang { get; set; }

		[JsonPropertyName("dir")]
		public string dir { get; set; }

		[JsonPropertyName("revision")]
		public string revision { get; set; }

		[JsonPropertyName("tid")]
		public string tid { get; set; }

		[JsonPropertyName("timestamp")]
		public DateTime timestamp { get; set; }

		[JsonPropertyName("description")]
		public string description { get; set; }

		[JsonPropertyName("description_source")]
		public string description_source { get; set; }

		[JsonPropertyName("content_urls")]
		public ContentUrls content_urls { get; set; }

		[JsonPropertyName("extract")]
		public string extract { get; set; }

		[JsonPropertyName("extract_html")]
		public string extract_html { get; set; }

		[JsonPropertyName("normalizedtitle")]
		public string normalizedtitle { get; set; }

		[JsonPropertyName("coordinates")]
		public Coordinates coordinates { get; set; }
	}

	public class Artist
	{
		[JsonPropertyName("html")]
		public string html { get; set; }

		[JsonPropertyName("text")]
		public string text { get; set; }
	}

	public class Captions
	{
		[JsonPropertyName("de")]
		public string de { get; set; }
	}

	public class ContentUrls
	{
		[JsonPropertyName("desktop")]
		public Desktop desktop { get; set; }

		[JsonPropertyName("mobile")]
		public Mobile mobile { get; set; }
	}

	public class Coordinates
	{
		[JsonPropertyName("lat")]
		public double lat { get; set; }

		[JsonPropertyName("lon")]
		public double lon { get; set; }
	}

	public class Credit
	{
		[JsonPropertyName("html")]
		public string html { get; set; }

		[JsonPropertyName("text")]
		public string text { get; set; }
	}

	public class Description
	{
		[JsonPropertyName("html")]
		public string html { get; set; }

		[JsonPropertyName("text")]
		public string text { get; set; }

		[JsonPropertyName("lang")]
		public string lang { get; set; }
	}

	public class Desktop
	{
		[JsonPropertyName("page")]
		public string page { get; set; }

		[JsonPropertyName("revisions")]
		public string revisions { get; set; }

		[JsonPropertyName("edit")]
		public string edit { get; set; }

		[JsonPropertyName("talk")]
		public string talk { get; set; }
	}

	public class Image
	{
		[JsonPropertyName("title")]
		public string title { get; set; }

		[JsonPropertyName("thumbnail")]
		public Thumbnail thumbnail { get; set; }

		[JsonPropertyName("image")]
		public Image image { get; set; }

		[JsonPropertyName("file_page")]
		public string file_page { get; set; }

		[JsonPropertyName("artist")]
		public Artist artist { get; set; }

		[JsonPropertyName("credit")]
		public Credit credit { get; set; }

		[JsonPropertyName("license")]
		public License license { get; set; }

		[JsonPropertyName("description")]
		public Description description { get; set; }

		[JsonPropertyName("wb_entity_id")]
		public string wb_entity_id { get; set; }

		[JsonPropertyName("structured")]
		public Structured structured { get; set; }

		[JsonPropertyName("source")]
		public string source { get; set; }

		[JsonPropertyName("width")]
		public int width { get; set; }

		[JsonPropertyName("height")]
		public int height { get; set; }
	}

	public class License
	{
		[JsonPropertyName("type")]
		public string type { get; set; }

		[JsonPropertyName("code")]
		public string code { get; set; }
	}

	public class Mobile
	{
		[JsonPropertyName("page")]
		public string page { get; set; }

		[JsonPropertyName("revisions")]
		public string revisions { get; set; }

		[JsonPropertyName("edit")]
		public string edit { get; set; }

		[JsonPropertyName("talk")]
		public string talk { get; set; }
	}

	public class Mostread
	{
		[JsonPropertyName("date")]
		public string date { get; set; }

		[JsonPropertyName("articles")]
		public List<Article> articles { get; set; }
	}

	public class Namespace
	{
		[JsonPropertyName("id")]
		public int id { get; set; }

		[JsonPropertyName("text")]
		public string text { get; set; }
	}

	public class Onthisday
	{
		[JsonPropertyName("text")]
		public string text { get; set; }

		[JsonPropertyName("pages")]
		public List<Page> pages { get; set; }

		[JsonPropertyName("year")]
		public int year { get; set; }
	}

	public class Originalimage
	{
		[JsonPropertyName("source")]
		public string source { get; set; }

		[JsonPropertyName("width")]
		public int width { get; set; }

		[JsonPropertyName("height")]
		public int height { get; set; }
	}

	public class Page
	{
		[JsonPropertyName("type")]
		public string type { get; set; }

		[JsonPropertyName("title")]
		public string title { get; set; }

		[JsonPropertyName("displaytitle")]
		public string displaytitle { get; set; }

		[JsonPropertyName("namespace")]
		public Namespace @namespace { get; set; }

		[JsonPropertyName("wikibase_item")]
		public string wikibase_item { get; set; }

		[JsonPropertyName("titles")]
		public Titles titles { get; set; }

		[JsonPropertyName("pageid")]
		public int pageid { get; set; }

		[JsonPropertyName("thumbnail")]
		public Thumbnail thumbnail { get; set; }

		[JsonPropertyName("originalimage")]
		public Originalimage originalimage { get; set; }

		[JsonPropertyName("lang")]
		public string lang { get; set; }

		[JsonPropertyName("dir")]
		public string dir { get; set; }

		[JsonPropertyName("revision")]
		public string revision { get; set; }

		[JsonPropertyName("tid")]
		public string tid { get; set; }

		[JsonPropertyName("timestamp")]
		public DateTime timestamp { get; set; }

		[JsonPropertyName("description")]
		public string description { get; set; }

		[JsonPropertyName("description_source")]
		public string description_source { get; set; }

		[JsonPropertyName("coordinates")]
		public Coordinates coordinates { get; set; }

		[JsonPropertyName("content_urls")]
		public ContentUrls content_urls { get; set; }

		[JsonPropertyName("extract")]
		public string extract { get; set; }

		[JsonPropertyName("extract_html")]
		public string extract_html { get; set; }

		[JsonPropertyName("normalizedtitle")]
		public string normalizedtitle { get; set; }
	}

	public class GetFeaturedArticleDTO
	{
		[JsonPropertyName("tfa")]
		public Tfa tfa { get; set; }

		[JsonPropertyName("mostread")]
		public Mostread mostread { get; set; }

		[JsonPropertyName("image")]
		public Image image { get; set; }

		[JsonPropertyName("onthisday")]
		public List<Onthisday> onthisday { get; set; }
	}

	public class Structured
	{
		[JsonPropertyName("captions")]
		public Captions captions { get; set; }
	}

	public class Tfa
	{
		[JsonPropertyName("type")]
		public string type { get; set; }

		[JsonPropertyName("title")]
		public string title { get; set; }

		[JsonPropertyName("displaytitle")]
		public string displaytitle { get; set; }

		[JsonPropertyName("namespace")]
		public Namespace @namespace { get; set; }

		[JsonPropertyName("wikibase_item")]
		public string wikibase_item { get; set; }

		[JsonPropertyName("titles")]
		public Titles titles { get; set; }

		[JsonPropertyName("pageid")]
		public int pageid { get; set; }

		[JsonPropertyName("thumbnail")]
		public Thumbnail thumbnail { get; set; }

		[JsonPropertyName("originalimage")]
		public Originalimage originalimage { get; set; }

		[JsonPropertyName("lang")]
		public string lang { get; set; }

		[JsonPropertyName("dir")]
		public string dir { get; set; }

		[JsonPropertyName("revision")]
		public string revision { get; set; }

		[JsonPropertyName("tid")]
		public string tid { get; set; }

		[JsonPropertyName("timestamp")]
		public DateTime timestamp { get; set; }

		[JsonPropertyName("description")]
		public string description { get; set; }

		[JsonPropertyName("description_source")]
		public string description_source { get; set; }

		[JsonPropertyName("content_urls")]
		public ContentUrls content_urls { get; set; }

		[JsonPropertyName("extract")]
		public string extract { get; set; }

		[JsonPropertyName("extract_html")]
		public string extract_html { get; set; }

		[JsonPropertyName("normalizedtitle")]
		public string normalizedtitle { get; set; }
	}

	public class Thumbnail
	{
		[JsonPropertyName("source")]
		public string source { get; set; }

		[JsonPropertyName("width")]
		public int width { get; set; }

		[JsonPropertyName("height")]
		public int height { get; set; }
	}

	public class Titles
	{
		[JsonPropertyName("canonical")]
		public string canonical { get; set; }

		[JsonPropertyName("normalized")]
		public string normalized { get; set; }

		[JsonPropertyName("display")]
		public string display { get; set; }
	}

	public class ViewHistory
	{
		[JsonPropertyName("date")]
		public string date { get; set; }

		[JsonPropertyName("views")]
		public int views { get; set; }
	}


}
