using TechTalk.SpecFlow;
using Emgu.CV;
using Emgu.CV.Structure;
using NUnit.Framework;


namespace ImageComparision.Steps
{
    [Binding]
    public class ImageStepDefinitions
    {
        private static string ProjectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public Image<Gray, Byte> imgToCompare;

        public Image<Gray, Byte> baseImg;


        [Test]
        public void SameImages()
        {
            imgToCompare = new Image<Gray, byte>(ProjectPath + "\\Images\\temp.jpg");
            baseImg = new Image<Gray, byte>(ProjectPath + "\\Images\\mobileqa.jpg");
            Assert.That(imgToCompare.Equals(baseImg));

        }

        [Test]
        public void ShowDifference()
        {

         //   imgToCompare = new Image<Gray, byte>(ProjectPath + "\\Images\\mobileqa.jpg");
          //  baseImg = new Image<Gray, byte>(ProjectPath + "\\Images\\mobileqaedited.jpg");

            /*//Convert to gray levels or split channels
            Image<Gray, Byte> imgToCompareGray = imgToCompare.Convert<Gray, byte>();
            Image<Gray, Byte> baseIngGray = baseImg.Convert<Gray, byte>();


            //Compare image and build mask
            Image<Gray, Byte> MaskDifferenceHigh = imgToCompareGray.Cmp(baseIngGray, CmpType.GreaterThan);
            Image<Gray, Byte> MaskDifferenceLow = imgToCompareGray.Cmp(baseIngGray, CmpType.LessThan);

            //Draw result
            Image<Gray, byte> result = imgToCompare.CopyBlank();

            result.SetValue(new Gray(5.0), MaskDifferenceHigh);
            result.SetValue(new Gray(2.0), MaskDifferenceLow);*/

            Image<Bgr, Byte> img1 = new Image<Bgr, Byte>(ProjectPath + "\\Images\\mobileqa.jpg");
            Image<Bgr, Byte> img2 = new Image<Bgr, Byte>(ProjectPath + "\\Images\\mobileqaedited.jpg");
            Image<Bgr, Byte> img3 = img2 - img1;

            string path1 = "C:\\Users\\ravilingam\\source\\repos\\ImageComparision\\ImageComparision\\Images\\";

            Random randomNumber = new Random();
            string randomName = randomNumber.Next(10000).ToString();
            img3.Save(path1 + "Difference_"+randomName+".jpg");

        }

    }

}
