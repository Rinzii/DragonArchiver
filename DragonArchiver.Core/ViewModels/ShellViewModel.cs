using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jot;

namespace DragonArchiver.Core.ViewModels;

public partial class ShellViewModel : ObservableObject
{
    private readonly Tracker _tracker;
    //private string _projectFile = @"D:\Test\FF2\FF2project.xml";



    public ShellViewModel(Tracker tracker)
    {
        _tracker = tracker;
        _tracker.Track("ShellViewModel");
    }


    public void RequestApplicationExit()
    {
        var canClose = true;
            //Editors.RequestSaveAllUserChanges();

        if (canClose)
        {
            //_projectService.CloseProjects();
            _tracker.PersistAll();
            Environment.Exit(0);
        }
    }
}