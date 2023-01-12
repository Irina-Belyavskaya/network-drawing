using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Commands
{
    ClientConnected = 2,// всем клиентам отправляется ник подключившегося ( подключ. к комнате)
    ClientDisconnected = 3, // вышел из комнаты
    ReciveBitmap = 4
}
