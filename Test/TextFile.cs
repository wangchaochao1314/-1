using System;
using System.IO;
namespace TextFile
{
    public class LogHelper
    {
        //文件流
        public FileStream fStream { get; set; }

        //写入器
        public StreamWriter sWrite { get; set; }

        //读取器
        public StreamReader sRead { get; set; }

        /// <summary>
        /// 写入的方法
        /// </summary>
        /// <param name="logPath">写入的路径</param>
        /// <param name="logContent">写入的内容</param>
        public void WriteLog(string logPath, string logContent)  //logPath路径  content写入内容
        {
            if (!File.Exists(logPath))
                File.Create(logPath).Close();
            try
            {
                fStream = new FileStream(logPath, FileMode.Append);
                sWrite = new StreamWriter(fStream);
                sWrite.WriteLine(DateTime.Now.ToString() + "\t" + logContent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sWrite.Close();
                fStream.Close();
            }
        }

        public void WriteTextFile(string str, string txtBarcodeFile)
        {

            if (!System.IO.File.Exists(txtBarcodeFile))  // 判断是否已有相同文件
            {
                FileStream fs1 = new FileStream(txtBarcodeFile, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            else
            {
                //保证每次文件的更新
                FileInfo finfo = new FileInfo(txtBarcodeFile);
                finfo.Delete();
                FileStream fs1 = new FileStream(txtBarcodeFile, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            System.IO.File.WriteAllText(txtBarcodeFile, str);
        }

        /// <summary>
        /// 写入的方法
        /// </summary>
        /// <param name="logPath">写入的路径</param>
        /// <param name="logContent1">写入的内容1</param>
        /// <param name="logContent2">写入的内容2</param>
        public void WriteLog(string logPath, string logContent1, string logContent2)  //logPath路径  content写入内容
        {
            try
            {
                if (!File.Exists(logPath))
                    File.Create(logPath).Close();
                fStream = new FileStream(logPath, FileMode.Append);
                sWrite = new StreamWriter(fStream);
                sWrite.WriteLine("\r\n" + DateTime.Now.ToString() + "\r\n" + logContent1 + "\r\n" + logContent2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sWrite.Close();
                fStream.Close();
            }

        }

        /// <summary>
        /// 往UR文件中写入测试数据
        /// </summary>
        /// <param name="barPath">路径</param>
        /// <param name="barContent">内容</param>
        public void WriteBarcodeUR(string barPath, string barContent)
        {
            if (!File.Exists(barPath))
            {
                try
                {
                    File.Create(barPath).Close();
                    fStream = new FileStream(barPath, FileMode.Append);
                    sWrite = new StreamWriter(fStream);
                    sWrite.WriteLine(barContent);
               //     Log4Helper.Info(barContent);
                }
                catch (Exception ex)
                {
                 //   Log4Helper.Error("保存UR文件出错", ex);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    sWrite.Close();
                    fStream.Close();
                }
            }
        }


        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="readpath">读取路径</param>
        /// <returns></returns>
        public string ReadFile(string readpath)
        {
            try
            {
                fStream = new FileStream(readpath, FileMode.Open);
                sRead = new StreamReader(fStream);
                string res = sRead.ReadToEnd();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sRead.Close();
                fStream.Close();
            }



        }

    }
}
