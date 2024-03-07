namespace HeliumBackend.models;

public class DBSettings
{
     
    public string DBName {get;set;} = null!;
    public string UsersCollectionName {get;set;} = null!;
    public string GroupsCollectionName {get;set;} = null!;
    public string ShowsCollectionName {get;set;} = null!;
    public string CueCardCollectionName {get;set;} = null!;
    public string CueCollectionName {get;set;} = null!;  
    public string TagCollectionName {get;set;} = null!;   
}