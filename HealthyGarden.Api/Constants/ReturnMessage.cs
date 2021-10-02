namespace HealthyGarden.Api.Constants
{
    public static class ReturnMessage
    {
        public static object UserNotFound => new { Message = "User not found" };
        public static object GardenNotFound => new { Message = "Garden not found" };
        public static object SettingNotFound => new { Message = "Setting not found" };
        public static object IdIsMandatory => new { Message = "Id is mandatory" };
        public static object MoistureStatusNotExist => new { Message = "Moisture Status does not exist" };
        public static object TemperatureStatusNotExist => new { Message = "Temperature Status does not exist" };

        public static object SuccessfullyDeleted => new { Message = "Successfully deleted" };
        public static object WrongPassword => new { Message = "Wrong Password" };

    }
}
