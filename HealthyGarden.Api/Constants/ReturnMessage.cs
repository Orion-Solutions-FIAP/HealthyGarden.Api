namespace HealthyGarden.Api.Constants
{
    public static class ReturnMessage
    {
        public static object UserNotFound => new { Message = "User not found" };
        public static object GardenNotFound => new { Message = "Garden not found" };
        public static object SettingNotFound => new { Message = "Setting not found" };
        public static object IdIsMandatory => new { Message = "Id is mandatory" };
        public static object StatusNotExist => new { Message = "Status does not exist" };
        public static object SuccessfullyDeleted => new { Message = "Successfully deleted" };
    }
}
