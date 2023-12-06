using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace mainWin.Controladores {//otra idea mas de chatgpt
    public class DebugInfo : INotifyPropertyChanged {
        private string _msg;
        private int _cont;

        public string Msg {
            get { return _msg; }
            set {
                if (_msg != value) {
                    _msg = value;
                    OnPropertyChanged(nameof(Msg));
                }
            }
        }

        public int cont {
            get { return _cont; }
            set {
                if (_cont != value) {
                    _cont = value;
                    OnPropertyChanged(nameof(cont));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
