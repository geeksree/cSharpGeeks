using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.Imaging
{
    public class ImageProcessor
    {
        public Bitmap ImageBitmap { get; set; }

        public ImageProcessor()
        {

        }

        public ImageProcessor(Bitmap image)
        {
            ImageBitmap = image;
        }

        public List<IntPoint> GetEdgePoints(Blob blob) 
        {            
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.ProcessImage(ImageBitmap);
            return blobCounter.GetBlobsEdgePoints(blob);                           
        }

        public List<Rectangle> GetBlobRectangles(Blob blob)
        {
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.ProcessImage(ImageBitmap);
            return blobCounter.GetObjectsRectangles().ToList();
        }

        public List<Blob> ExtractBlob()
        {
            // create instance of blob counter
            BlobCounter blobCounter = new BlobCounter();
            // process input image
            blobCounter.ProcessImage(ImageBitmap);
            
            // get information about detected objects   
            
            Blob[] blobArray = blobCounter.GetObjectsInformation();

            foreach(Blob blobdata in blobArray)
            {
                blobCounter.ExtractBlobsImage(ImageBitmap, blobdata, true);
            }
            
            return blobArray.ToList();
        }
        
        public List<Blob> ExtractBlob(int maxWidth, int maxHeight, int minWidth, int minHeight)
        {
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.MinHeight = minHeight;
            blobCounter.MinWidth = minWidth;
            blobCounter.MaxWidth = maxWidth;
            blobCounter.MaxHeight = maxHeight;
            blobCounter.FilterBlobs = true;
            // process input image
            blobCounter.ProcessImage(ImageBitmap);

            // get information about detected objects   

            Blob[] blobArray = blobCounter.GetObjectsInformation();

            foreach (Blob blobdata in blobArray)
            {
                blobCounter.ExtractBlobsImage(ImageBitmap, blobdata, true);
            }

            return blobArray.ToList();
        }        

        public Bitmap ConvertTOGrayScale(double cr, double cg, double cb)
        {
            Grayscale grayScaleFilter = new Grayscale(cr, cg, cb);
            Bitmap convertedImage = grayScaleFilter.Apply(ImageBitmap);
            ImageBitmap = convertedImage;
            return convertedImage;
        }

        public Bitmap BinarizeImage(int threshold)
        {
            Threshold filter = new Threshold(threshold);
            //ConvertTOGrayScale(0.2125, 0.7154, 0.0721);
            Bitmap convertedImage = filter.Apply(ImageBitmap);
            ImageBitmap = convertedImage;
            return convertedImage;
        }

        public void SaveBlobsToLocal(string path, List<Blob> blobs)
        {
            UnmanagedImage image;
            foreach(Blob blob in blobs)
            {
                image = blob.Image;
                image.ToManagedImage().Save(path + @"\Image_" + Guid.NewGuid() + ".png");
            }
        }
    }
}
