using _09_EmployeeRecordsManagementCopyTwoProj.ViewModels.DepartmentVM;
using _09_EmployeeRecordsManagementCopyTwoProj.ViewModels.EmployeeVM;
using AutoMapper;
using EmployeeRecords.Models.EntityModels;

namespace _09_EmployeeRecordsManagementCopyTwoProj.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
        }
    }
}
