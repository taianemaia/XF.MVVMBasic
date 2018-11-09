using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.MVVMBasic.Model;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel
    {
        #region Propriedades         
        public Aluno AlunoModel { get; set; }
        public Aluno Selecionado { get; set; }
        public ObservableCollection<Aluno> Alunos { get; set; } = new ObservableCollection<Aluno>();

        // UI Events
        public ICommand OnNovoCMD { get; set; }

        public ICommand OnRemoveCMD { get; set; }

        public SalvarAluno OnSalvarCMD { get; set; }

        #endregion

        public AlunoViewModel()
        {
            OnNovoCMD = new Command(OnNovo);
            OnRemoveCMD = new Command(OnRemove);
            OnSalvarCMD = new SalvarAluno(this);

            Alunos.Add(new Aluno()
            {
                Nome = "nome",
                RM = "rm",
                Email = "email"
            });

            Alunos.Add(new Aluno()
            {
                Nome = "Taiane",
                RM = "331748",
                Email = "tayanemaya@hotmail.com"
            });            
        }

        private void OnNovo()
        {
            App.AlunoVM.AlunoModel = new Aluno();
            App.Current.MainPage.Navigation.PushAsync(new View.NovoAlunoView() { BindingContext = App.AlunoVM });
        }

        public void OnSalvar(Aluno paramAluno)
        {
            try
            {
                if (paramAluno == null)
                    throw new Exception("Informe um usuário");

                Alunos.Add(paramAluno);
                App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "Ok");
            }
        }

        public void OnRemove()
        {
            Alunos.Remove(Selecionado);
        }

    }


    public class SalvarAluno : ICommand
    {
        AlunoViewModel AlunoVM;
        public SalvarAluno(AlunoViewModel paramVM)
        {
            AlunoVM = paramVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AlunoVM.OnSalvar(parameter as Aluno);
        }
    }
}
