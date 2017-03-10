using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using WebSite.Config;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;

namespace ImgMake
{
    class Program
    {
        static void Main(string[] args)
        {

            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode = qrEncoder.Encode("Http://tbt.kags.com");
            //保存成png文件
            string filename = @"E:\tbt\toubaotuan\WebSite\WebSite\Img\MakeQR.png";
            GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                render.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);
            }
            string img2Patn = @"E:\tbt\toubaotuan\WebSite\WebSite\Img\2.jpg";
            ImgHelp.CatImg(img2Patn, "这是测试的字", filename);
          
        }
    }
}
