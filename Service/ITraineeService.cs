using System.Collections.Generic;

namespace Win_UI_Sample.Services
{
    public interface ITraineeService
    {
        void AddTrainee(Dictionary<string, object> traineeData);
        public List<Dictionary<string, object>> GetTrainees();
    }
}