using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.WebPages;

namespace MWCore.App_Code
{
    public class WhiteSpaceModule : IHttpModule
    {
        void IHttpModule.Dispose()
        {

        }
        void IHttpModule.Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(context_BeginRequest);
            context.PreSendRequestHeaders += context_PreSendRequestHeaders;
            WebPageHttpHandler.DisableWebPagesResponseHeader = true;
        }
        private void context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            if(HttpContext.Current != null)
            {
                HttpContext.Current.Response.Headers.Remove("ETag");
                HttpContext.Current.Response.Headers.Remove("Server");
            }
        }
        private void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app.Request.CurrentExecutionFilePath.EndsWith("/") || app.Request.CurrentExecutionFilePath.EndsWith(".cshtml"))
            {
                app.Response.Filter = new WhiteSpaceFilter(app.Response.Filter);
            }
        }

        private class WhiteSpaceFilter : Stream
        {
            public override bool CanRead
            {
                get { return true; }
            }

            public override bool CanSeek
            {
                get { return true; }
            }

            public override bool CanWrite
            {
                get { return true; }
            }
            public override void Flush()
            {
                _sink.Flush();
            }
            public override long Length
            {
                get { return 0; }
            }

            private long _position;
            public override long Position
            {
                get { return _position; }
                set { _position = value; }
            }

            public WhiteSpaceFilter(Stream sink)
            {
                _sink = sink;
            }
            private Stream _sink;
            public override int Read(byte[] buffer, int offset, int count)
            {
                return _sink.Read(buffer, offset, count);
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                return _sink.Seek(offset, origin);
            }
            public override void SetLength(long value)
            {
                _sink.SetLength(value);
            }
            public override void Close()
            {
                _sink.Close();
            }
            private static readonly Regex REGEX_BETWEEN_TAGS = new Regex(@">\s+<", RegexOptions.Compiled);
            private static readonly Regex REGEX_BETWEEN_BREAKS = new Regex(@"\n\s+", RegexOptions.Compiled);
            public override void Write(byte[] buffer, int offset, int count)
            {
                byte[] data = new byte[count];
                Buffer.BlockCopy(buffer, offset, data, 0, count);
                string html = System.Text.Encoding.Default.GetString(buffer);
                html = Regex.Replace(html, @">\s+<", "><");
                html = Regex.Replace(html, @"\n\s+", " ");
                byte[] outdata = System.Text.Encoding.Default.GetBytes(html);
                _sink.Write(outdata, 0, outdata.GetLength(0));
            }
        }
    }
}