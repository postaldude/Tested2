using System;
using System.Collections;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    /*public class OrdinaryUrl
    {
        public string? type { get; set; }
        public string? url { get; set; }
        public string? suggested_link_text { get; set; }

        public OrdinaryUrl(string? type, string? url, string? suggested_link_text)
        {
            this.type = type;
            this.url = url;
            this.suggested_link_text = suggested_link_text;
        }

    }*/

    /*
    public class InformationCriminals
    {


       
        [JsonProperty("@id")] public string?  Newid { get; set; }
        [JsonProperty("title")] public string?  Title { get; set; }
        [JsonProperty("field_offices")] public string? Office { get; set; }
        [JsonProperty("details")] public string? Detail { get; set; }
        [JsonProperty("sex")] public string? Pol { get; set; }
        [JsonProperty("nationality")] public string? National { get; set; }
        [JsonProperty("age_max")] public int? Age { get; set; }
        [JsonProperty("height_max")] public int? Height { get; set; }
        [JsonProperty("race_raw")] public string? Race  { get; set; }
        [JsonProperty("hair_raw")] public string? Hair { get; set; }
        [JsonProperty("languages")] public string? Language { get; set; }
        [JsonProperty("files")] public string? Urlpdf { get; set; }



        public InformationCriminals(string? underNewid, string? underTitle, string? underOffice, string?
                underDetails, string? underPol, string? underNational, int? underAge, int? underHeight,
            string? underRace,
            string? underHair, string? underLanguage, string? underPdf)
        {
            this.Newid = underNewid;
            this.Title = underTitle;
            this.Office = underOffice;
            this.Detail = underDetails;
            this.Pol = underPol;
            this.National = underNational;
            this.Age = underAge;
            this.Height = underHeight;
            this.Race = underRace;
            this.Hair = underHair;
            this.Language = underLanguage;
            this.Urlpdf = underPdf;
         




        }
    }*/
    
   public class Items 
   {
        public class Coordinate
    {
        public double lng { get; set; }
        public double lat { get; set; }
        public string formatted { get; set; }
    }

    public class File
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Image
    {
        public string large { get; set; }
        public string caption { get; set; }
        public string original { get; set; }
        public string thumb { get; set; }
    }

    public class Item
    {
        public object locations { get; set; }
        public List<string> field_offices { get; set; }
        public string details { get; set; }
        public List<string> possible_countries { get; set; }
        public List<Coordinate> coordinates { get; set; }
        public List<string> occupations { get; set; }
        public string title { get; set; }
        public object age_max { get; set; }
        public string complexion { get; set; }
        public int? weight_max { get; set; }
        public string remarks { get; set; }
        public string eyes { get; set; }
        public string ncic { get; set; }
        public string path { get; set; }
        public string weight { get; set; }
        public int? height_min { get; set; }
        public string scars_and_marks { get; set; }
        public int? weight_min { get; set; }
        public List<string> dates_of_birth_used { get; set; }
        public string nationality { get; set; }
        public string description { get; set; }
        public int? height_max { get; set; }
        public List<string> languages { get; set; }
        public string hair_raw { get; set; }
        public string hair { get; set; }
        public List<string> aliases { get; set; }
        public DateTime modified { get; set; }
        public string eyes_raw { get; set; }
        public List<string> possible_states { get; set; }
        public string status { get; set; }
        public object warning_message { get; set; }
        public string url { get; set; }
        public string reward_text { get; set; }
        public List<File> files { get; set; }
        public string place_of_birth { get; set; }
        public object legat_names { get; set; }
        public object additional_information { get; set; }
        public List<Image> images { get; set; }
        public DateTime publication { get; set; }
        public List<string> subjects { get; set; }
        public string build { get; set; }
        public int reward_min { get; set; }
        public object suspects { get; set; }
        public string person_classification { get; set; }
        public object age_range { get; set; }
        public object age_min { get; set; }
        public int reward_max { get; set; }
        public string race_raw { get; set; }
        public string race { get; set; }
        public string uid { get; set; }
        public string sex { get; set; }
        public string caution { get; set; }

        [JsonProperty("@id")]
        public string id { get; set; }
    }

    public class Root
    {
        public int total { get; set; }
        public List<Item> items { get; set; }
        public int page { get; set; }
    }

  
   }


        class Program
        {
            private static async Task Main()
            {
            
                using var client = new HttpClient();
                var content = await client.GetStringAsync("https://api.fbi.gov/wanted/v1/list");
                HttpResponseMessage response = await client.GetAsync(content);
                response.EnsureSuccessStatusCode();
                var resp = await response.Content.ReadAsStringAsync();
               // List<Items> contributors = JsonConvert.DeserializeObject<List<Items>>(content);
                
                Items item = JsonConvert.DeserializeObject<Items>>(resp);

            

                foreach (var result  in  item.title)
                {
                    Console.WriteLine(result);
                }
             
            }
        }
    
}

/*class WantedPersons
{
  public string title { get; set; }
  public char dates_of_birth_used { get; set; }
  public string nationality { get; set; }
    public string race_raw { get; set; }
    public string race { get; set; }
    public string hair_raw { get; set; }
    public string place_of_birth { get; set; }
    public string person_classification { get; set; }
    public string description { get; set; }
    public int height_max { get; set; }
    public int height_min { get; set; }

    

    public override string ToString()
    {
        return $"{title}: {dates_of_birth_used}: {nationality} nationality: {race_raw}:" +
               $" {race}: {hair_raw}: {place_of_birth}: {person_classification}: {description}:" +
               $"{height_max}: {height_min}";
    }
}

class Program
{
     static async Task Main(string[] args)
    {
        
        using var client = new HttpClient();

        client.BaseAddress = new Uri("https://www.fbi.gov/wanted");
        client.DefaultRequestHeaders.Add("MostWanted Persons", "");
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var url = "repos/symfony/symfony/persons";
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var resp = await response.Content.ReadAsStringAsync();

        List<WantedPersons> persons = JsonConvert.DeserializeObject<List<WantedPersons>>(resp);
        persons.ForEach(Console.WriteLine);
        
        
        
        
        
    }*/
    

