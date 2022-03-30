using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public interface IFileRepository
    {
        List<FileCaseViewModel> GetFileList(int id=0);
        HandleException Insert(FileCaseViewModel fileCaseViewModel);
        FileCaseViewModel GetFileCaseByID(int id);
        HandleException Edit(FileCaseViewModel fileCaseViewModel);
        FileCaseViewModel Details(int id);
        FileCaseViewModel Delete(int id=0);
        HandleException Delete(FileCaseViewModel fileCaseView);
    }
}