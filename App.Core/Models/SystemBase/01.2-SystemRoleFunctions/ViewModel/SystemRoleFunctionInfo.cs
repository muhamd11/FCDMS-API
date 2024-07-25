namespace App.Core.Models.SystemBase._01._2_SystemRoleFunctions.ViewModel
{
    public class SystemRoleFunctionInfo
    {
        public string systemRoleFunctionModule { get; set; }
        public List<SystemRoleFunction> systemRoleFunctions { get; set; } = new List<SystemRoleFunction>();
    }
}