#nullable enable
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.Exception;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Encoding.Pipeline;
using AdofaiBin.Serialization.Encoding.Pipeline.Stage;
using AdofaiBin.Serialization.Encoding.Pipeline.Stage.Block;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Encoding
{
    public sealed class AdofaiBinEncoder
    {
        private readonly EncodingOptions _options;

        public AdofaiBinEncoder(EncodingOptions? options = null)
        {
            _options = options ?? new EncodingOptions();
        }

        private readonly JsonLoadSettings _jsonSettings = new()
        {
            CommentHandling = CommentHandling.Ignore,
            LineInfoHandling = LineInfoHandling.Ignore
        };

        private EncodingOptions MergeOptions(EncodingOptions? options) => options ?? _options;

        private async Task RunEncodingAsync(JObject json, Stream output, EncodingOptions options, CancellationToken ct)
        {
            var opt = MergeOptions(options);
            var sink = StreamBinarySink.FromStream(output, opt.LeaveOpen);
            using var ctx = new EncodingContext(opt, sink, json);
            var pipeline = new EncodingPipeline(
                new BuildModelStage(),
                new BuildTablesStage(),
                new CanonicalizeStage(),
                new WriteBlocksStage(
                    new HeaderBlock(),
                    new DictBlock()
                )
            );

            await pipeline.RunAsync(ctx, ct).ConfigureAwait(false);
        }

        public void Encode(JObject json, Stream output, EncodingOptions? options = null)
        {
            RunEncodingAsync(json, output, MergeOptions(options), CancellationToken.None).GetAwaiter().GetResult();
        }

        public void Encode(string json, Stream output, EncodingOptions? options = null)
        {
            var rootJson = JObject.Parse(json, _jsonSettings);
            if (rootJson == null)
            {
                throw new EncodingInvalidJsonException();
            }

            Encode(rootJson, output, options);
        }

        public void EncodeFromFile(string path, Stream output, EncodingOptions? options = null)
        {
            Encode(File.ReadAllText(path), output, options);
        }

        public async Task EncodeAsync(JObject json, Stream output, EncodingOptions? options = null, CancellationToken ct = default)
        {
            await RunEncodingAsync(json, output, MergeOptions(options), ct).ConfigureAwait(false);
        }

        public async Task EncodeAsync(string json, Stream output, EncodingOptions? options = null, CancellationToken ct = default)
        {
            var task = Task.Run(() => JObject.Parse(json, _jsonSettings), ct);
            var jObject = await task;

            if (jObject == null)
            {
                throw new EncodingInvalidJsonException();
            }

            await EncodeAsync(jObject, output, options, ct);
        }

        public async Task EncodeFromFileAsync(string path, Stream output, EncodingOptions? options = null, CancellationToken ct = default)
        {
            using var fileStream = File.OpenText(path);
            await EncodeAsync(await fileStream.ReadToEndAsync(), output, options, ct);
        }

        public bool TryEncode(string json, Stream output, out EncodeResult result, EncodingOptions? options = null)
        {
            try
            {
                Encode(json, output, options);
                result = EncodeResult.Ok;
                return true;
            }
            catch (EncodingFutureVersionException)
            {
                result = EncodeResult.FutureVersion;
                return false;
            }
            catch (EncodingInvalidJsonException)
            {
                result = EncodeResult.InvalidJson;
                return false;
            }
            catch (OperationCanceledException)
            {
                result = EncodeResult.Cancelled;
                return false;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);

                result = EncodeResult.UnknownError;
                return false;
            }
        }

        public bool TryEncodeFromFile(string path, Stream output, out EncodeResult result, EncodingOptions? options = null)
        {
            try
            {
                EncodeFromFile(path, output, options);
                result = EncodeResult.Ok;
                return true;
            }
            catch (EncodingFutureVersionException)
            {
                result = EncodeResult.FutureVersion;
                return false;
            }
            catch (EncodingInvalidJsonException)
            {
                result = EncodeResult.InvalidJson;
                return false;
            }
            catch (OperationCanceledException)
            {
                result = EncodeResult.Cancelled;
                return false;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);

                result = EncodeResult.UnknownError;
                return false;
            }
        }
    }
}