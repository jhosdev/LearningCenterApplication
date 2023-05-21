using LearningCenter.Infrastructure.Context;

namespace LearningCenter.Infrastructure;

public class UserOracleInfrastructure : IUserInfrastructure
{
    public List<string> GetAll()
    {
        LearningCenterContext learningCenterContext = new LearningCenterContext();

        var users = learningCenterContext.Users.ToList();
        
        // Create a list of string values from the retrieved users
        List<string> userList = users.Select(user => user.Username).ToList();

        return userList;
    }
}