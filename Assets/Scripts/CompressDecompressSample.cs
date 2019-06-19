using System.Collections;
using System.Collections.Generic;
using System.IO;
using TurboJpegWrapper;
using UnityEngine;

public class CompressDecompressSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        TJDecompressor decompressor = new TJDecompressor();
        TJCompressor compressor = new TJCompressor();

        byte[] compressedImage = File.ReadAllBytes("Assets/Images/image.jpg");

        float startTime = Time.realtimeSinceStartup;
        DecompressedImage decompressedImage = decompressor.Decompress(compressedImage, TJPixelFormat.RGBA, TJFlags.None);
        Debug.Log("Image decompressed. Execution time : " + (Time.realtimeSinceStartup - startTime).ToString() + " secondes.");     

        
        startTime = Time.realtimeSinceStartup;
        byte[] recompressedImage = compressor.Compress(decompressedImage.Data, decompressedImage.Stride, decompressedImage.Width, decompressedImage.Height, decompressedImage.PixelFormat, TJSubsamplingOption.Chrominance420, 92, TJFlags.None);
        Debug.Log("Image recompressed. Execution time : " + (Time.realtimeSinceStartup - startTime).ToString() + " secondes.");

        File.WriteAllBytes("Assets/Images/recompressedImage.jpg", recompressedImage);
        Debug.Log("Recompressed image saved at : Assets/Images/recompressedImage.jpg");
        ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
