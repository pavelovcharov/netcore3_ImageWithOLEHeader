using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace netcore3_ImageWithOLEHeader {

    [TestFixture]
    public class TestClass {
        [Test]
        public void ImageWithOLEHeader() {
            var type = GetType();
            var assembly = type.Assembly;
            using(var imageStream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".NorthwindDBImage.bmp")) {
                using(var ms = new MemoryStream()) {
                    imageStream.CopyTo(ms);
                    var converter = new ImageConverter();
                    var image = converter.ConvertFrom(ms.ToArray());
                    Assert.IsNotNull(image);
                }
            }
        }
    }
}
