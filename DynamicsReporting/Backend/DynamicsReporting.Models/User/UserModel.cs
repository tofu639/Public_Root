public class UserModel
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime? UserLastLogin { get; set; }
    public bool UserStatus { get; set; }
}


public class UserGroupReportModel
{
    public int UserGroupReportID { get; set; }
    public int GroupReportID { get; set; }
    public int UserID { get; set; }
}
