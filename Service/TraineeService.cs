using System.Collections.Generic;
using Win_UI_Sample.Repositories;
using Win_UI_Sample.Service;
using Win_UI_Sample.Services;

namespace Win_UI_Sample.Service
{
    public class TraineeService : ITraineeService
    {
        public readonly ITraineeRepository _traineeRepository = TraineeRepository.Instance;

        public void AddTrainee(Dictionary<string, object> traineeData)
        {
            _traineeRepository.AddTrainee(traineeData);
        }
        public List<Dictionary<string, object>> GetTrainees()
        {
            return _traineeRepository.GetAllTrainees();
        }
    }
}