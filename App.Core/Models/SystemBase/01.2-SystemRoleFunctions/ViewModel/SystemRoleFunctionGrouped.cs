namespace App.Core.Models.SystemBase._01._2_SystemRoleFunctions.ViewModel
{
    public class SystemRoleFunctionGrouped
    {
        public string systemRoleFunctionModule { get; set; }
        public List<SystemRoleFunctionInfo> systemRoleFunctions { get; set; } = new List<SystemRoleFunctionInfo>();
    }
}