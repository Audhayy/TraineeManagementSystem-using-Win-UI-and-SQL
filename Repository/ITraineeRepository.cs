using System.Collections.Generic;

namespace Win_UI_Sample.Repositories
{
    public interface ITraineeRepository
    {
        void AddTrainee(Dictionary<string, object> traineeData);
        List<Dictionary<string, object>> GetAllTrainees();
    }
}