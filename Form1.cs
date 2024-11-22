using System.Runtime.InteropServices;

namespace Senac.WF.Viru
{
    public partial class Form1 : Form
    {
        // variaveis
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        // metodo que executa o evento de clique
        [DllImport("user32.dll",
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(
            int dwFlags,
            int dx,
            int dy,
            int cButtons,
            int dwExtraInfo);

        // gera numeros aleatorios
        private Random random = new();

        private void MoverCursorMouse()
        {
            // obter a largura da tela = 1360
            int largura = Screen.PrimaryScreen.Bounds.Width;
            //obter a altura da tela = 768
            int altura = Screen.PrimaryScreen.Bounds.Height;
            // gerar uma posicao aleatoria X
            int posX = random.Next(largura);
            // gerar uma posicao aleatoria Y
            int posY = random.Next(altura);
            // Posicionar o cursor do mouse na posicao x,y
            Cursor.Position = new Point(posX, posY);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoverCursorMouse();

            // loop de 1 até 10
            // repetição de 10 x
            for (int i = 1; i <= 10; i++)
            {
                MoverCursorMouse();
                Clicar();
                //Clicar();
                // esperar 100 milisegundos
                Thread.Sleep(1000);
            }
        }

        private void Clicar()
        {
            // executa o clique completo do mouse
            // Pressiona o botão esquerdo
            mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            // Solta o botão esquerdo
            mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }
    }
}
