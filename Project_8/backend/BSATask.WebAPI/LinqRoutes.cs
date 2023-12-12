namespace BSATask.WebAPI
{
    public class LinqRoutes
    {
        private const string baseUrl = "/api/linq";

        public const string GetTasksCountInProjectsByUserIdAsync = baseUrl + "/getTasksCountInProjectsByUserId";
        public const string GetCapitalTasksByUserIdAsync = baseUrl + "/getCapitalTasksByUserId";
        public const string GetProjectsByTeamSizeAsync = baseUrl + "/getProjectsByTeamSize";
        public const string GetSortedTeamByMembersWithYearAsync = baseUrl + "/getSortedTeamByMembersWithYear";
        public const string GetSortedUsersWithSortedTasksAsync = baseUrl + "/getSortedUsersWithSortedTasks";
        public const string GetUserInfoAsync = baseUrl + "/getUserInfo";
        public const string GetProjectsInfoAsync = baseUrl + "/getProjectsInfo";
        public const string GetSortedFilteredPageOfProjectsAsync = baseUrl + "/getSortedFilteredPageOfProjects";
    }
}
