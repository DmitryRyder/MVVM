using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Course_Work
{
    class MainWindowVM
    {
        IFileService fileService;
        IDialogService dialogService;
        AddOrEditBicycleDialogService addOrEditBicycleDialog;
        MainWindow t;

        static RepositoryCreator RepositoryCreator;
        public static string Path = "./Repositories/"; // или string dirName = @".\Repositories"; - путь каталога, в котором был вызван исполняющий программу файл

        static bool CheckOpenSave = false;

        public ObservableCollection<Bicycle> Bicycles { get; private set; }
        public StatusBarService Statusbar { get; private set; }

        private string[] myModels = new string[] { "Quest-Disc", "4919M-24", "ENERGY-26", "26S020", "Cosmic-14", "PBK-1601" };
        private string[] myManufactures = new string[] { "Aist", "GREEN-WAY", "STREAM", "Novatrack", "Polaris", "STELS" };
        private int[] myYears = new int[] { 2014, 2015, 2016, 2017, 2018, 2019 };
        private int[] myNumberOfSpeeds = new int[] { 3, 11, 15, 23, 30, 33 };
        private string[] myTypes = new string[] { "Детский", "Подростковый", "Взрослый", "Детский", "Подростковый", "Взрослый" };
        private string[] myMaterials = new string[] { "Сталь", "Углепластик", "Титан", "Молибден", "Хромомолибденовая-сталь", "Алюминий" };
        private int[] mySizes = new int[] { 40, 47, 35, 37, 42, 33 };

        public MainWindowVM(StatusBarService statusBar, MainWindow y)
        {
            t = y;
            dialogService = new DefaultDialogService();
            Bicycles = new ObservableCollection<Bicycle>();
            addOrEditBicycleDialog = new AddOrEditBicycleDialogService();
            Statusbar = statusBar;
            Statusbar.CurrentRepository = "Репозиторий не создан";
            Statusbar.State = "Создайте или откройте репозиторий";
            RepositoryCreator = RepositoryCreator.Instance;
            DirectoryInfo dirInfo = new DirectoryInfo("./Repositories");
            if (!dirInfo.Exists) dirInfo.Create();
        }

        #region Relay Commands
        public ICommand AddStarCommand
        {
            get
            {
                return new RelayCommand(p => AddBicycle());
            }
        }

        public ICommand WriteToRepositoryCommand
        {
            get
            {
                return new RelayCommand(p => RepositoryCreator.Repository.UpdateRepository(Bicycles), (obj) => RepositoryCreator.Repository != null);
            }
        }

        public ICommand ReadRepositoryCommand
        {
            get
            {
                return new RelayCommand(p => RepositoryCreator.Repository.ReadRepository(Bicycles), (obj) => (RepositoryCreator.Repository != null) ? RepositoryCreator.Repository.IsClear : false);
            }
        }

        public ICommand CreateMemoryRepositoryCommand
        {
            get
            {
                return new RelayCommand(p => CreateRepository(RepositoryType.MEMORY));
            }
        }

        public ICommand CreateTextRepositoryCommand
        {
            get
            {
                return new RelayCommand(p => CreateRepository(RepositoryType.TEXT));
            }
        }

        public ICommand CreateBinaryRepositoryCommand
        {
            get
            {
                return new RelayCommand(p => CreateRepository(RepositoryType.BINARY));
            }
        }

        public ICommand DeleteRepositoryCommand
        {
            get
            {
                return new RelayCommand(p => RepositoryCreator.Repository.DeleteDataRepository(Bicycles), (obj) => (RepositoryCreator.Repository != null) ? RepositoryCreator.Repository.IsClear : false);
            }
        }

        public ICommand ClearTable
        {
            get
            {
                return new RelayCommand(p => Bicycles.Clear());
            }
        }

        private RelayCommand inputDialogCommand;
        public RelayCommand InputDialogCommand
        {
            get
            {
                return inputDialogCommand ?? (inputDialogCommand = new RelayCommand(obj =>
                {
                    try
                    { 
                        addOrEditBicycleDialog.InputDialog(t);

                        Bicycle b = addOrEditBicycleDialog.GetData();
                        if(b != null)
                            Bicycles.Add(addOrEditBicycleDialog.GetData());
                        
                    }
                    catch (InvalidOperationException ex)
                    {
                        
                    }
                }));
            }
        }

        private RelayCommand editDialogCommand;
        public RelayCommand EditDialogCommand
        {
            get
            {
                return editDialogCommand ?? (editDialogCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        int index = 0;
                        for (int i = 0; i < Bicycles.Count; i++)
                        {
                            if (t.ID == Bicycles[i].ID)
                            {
                                addOrEditBicycleDialog.EditDialog(t, Bicycles[i]);
                                index = i;
                                break;
                            }
                        }
                        Bicycles[index] = addOrEditBicycleDialog.GetData();
                    }
                    catch (InvalidOperationException ex)
                    {

                    }
                }, (obj) => t.isChanded));
            }
        }

        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog(Path) == true)
                          {
                              CheckOpenSave = true;
                              CreateRepository(dialogService.TypeOfReposirory);
                              ObservableCollection<Bicycle> bicycleslist = fileService.Open(dialogService.FilePath);
                              Bicycles.Clear();
                              foreach (Bicycle p in bicycleslist)
                                  Bicycles.Add(p);
                              dialogService.ShowMessage("Файл загружен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog(Path) == true)
                          {
                              CheckOpenSave = true;
                              CreateRepository(dialogService.TypeOfReposirory);
                              fileService.Save(dialogService.FilePath, Bicycles);
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }
        #endregion

        #region Methods
        private void CreateRepository(RepositoryType t)
        {
            switch (t)
            {
                case RepositoryType.BINARY: fileService = new BinaryFileService(); break;
                case RepositoryType.TEXT: fileService = new TextFileService(); break;
            }

            if (t != RepositoryType.MEMORY && !CheckOpenSave)
            {
                try
                {
                    if (dialogService.SaveFileDialog(Path, t) == true)
                    {
                        fileService.Save(dialogService.FilePath, Bicycles);
                        RepositoryCreator.Initialize(t, dialogService.FilePath);
                        Statusbar.SelectRepository(t, dialogService.FilePath);
                        dialogService.ShowMessage("Файл создан");
                    }
                }
                catch (Exception ex)
                {
                    dialogService.ShowMessage(ex.Message);
                }
            }        

            if (t == RepositoryType.MEMORY)
            {
                RepositoryCreator.Initialize(t, dialogService.FilePath);
                RepositoryCreator.Repository.CreateRepository();
                Statusbar.SelectMemoryRepository();
                return;
            }
            CheckOpenSave = false;
        }

        private void AddBicycle()
        {
            Random myRandom = new Random((Int32)DateTime.Now.Ticks);
            string myModel = myModels[GetRandomNumber()];
            string myManufacture = myManufactures[GetRandomNumber()];
            int myYear = myYears[GetRandomNumber()];
            int myNumberOfSpeed = myNumberOfSpeeds[GetRandomNumber()];
            string myType = myTypes[GetRandomNumber()];
            BicycleFrame Frame = new BicycleFrame(myMaterials[GetRandomNumber()], mySizes[GetRandomNumber()]);
            Bicycle s = new Bicycle(myModel, myManufacture, myYear, myNumberOfSpeed, myType, Frame);
            Bicycles.Add(s);

            int GetRandomNumber()
            {
                return myRandom.Next(0, 6);
            }
        }

        //private void AddStar1()
        //{
        //    Star s = new Star();
        //    StarList.Add(s);
        //}
        #endregion
    }
}
