using System.ComponentModel.DataAnnotations;



public class PageConfigItem
{
    public string serverdb { get; set; }   // Branch / Instance
    public string dbName { get; set; }     // Database
    public string sp { get; set; }         // Stored Procedure Name
    public Dictionary<string, object> parameters { get; set; }
}

public class PageConfig
{
    public int pageId { get; set; }
    public List<PageConfigItem> pageConfigItem { get; set; }
}
