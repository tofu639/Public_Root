using System.ComponentModel.DataAnnotations;

//public class RequestPage
//{
//    [Required]
//    public int PageId { get; set; }
//    public List<SqlConfigItem> ConfSql { get; set; } = new();
//}


//public class SqlConfig
//{
//    public string db { get; set; }
//    public string sp { get; set; }
//}

public class SqlConfigItem
{
    public string serverdb { get; set; }   // Branch / Instance
    public string dbName { get; set; }     // Database
    public string sp { get; set; }         // Stored Procedure Name
    public Dictionary<string, object> parameters { get; set; }
}

public class PageConfig
{
    public int pageId { get; set; }
    public List<SqlConfigItem> sqlConfigItem { get; set; }
}
