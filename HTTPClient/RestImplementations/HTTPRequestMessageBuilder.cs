using System;
using System.Collections.Generic;
using System.Net.Http;

public class HttpRequestMessageBuilder
{
    private HttpMethod _method;
    private Uri _requestUri;
    private HttpContent _content;
    private Dictionary<string, string> _headers;

    public HttpRequestMessageBuilder()
    {
        _headers = new Dictionary<string, string>();
    }

    public HttpRequestMessageBuilder WithMethod(HttpMethod method)
    {
        _method = method;
        return this;
    }

    public HttpRequestMessageBuilder WithRequestUri(Uri requestUri)
    {
        _requestUri = requestUri;
        return this;
    }

    public HttpRequestMessageBuilder WithContent(HttpContent content)
    {
        _content = content;
        return this;
    }

    public HttpRequestMessageBuilder AddHeader(string key, string value)
    {
        _headers[key] = value;
        return this;
    }

    public HttpRequestMessage Build()
    {
        var request = new HttpRequestMessage
        {
            Method = _method,
            RequestUri = _requestUri,
            Content = _content
        };

        // validations

        if(_requestUri == null)
        {
            Console.WriteLine("REST call without URI not allowed");
            throw new Exception("error in builder");
        }

        if(_method == HttpMethod.Post && _content == null)
        {
            Console.WriteLine("Post call without body not allowed");
            throw new Exception("error in builder");
        }

        if (_method == HttpMethod.Get && _content != null)
        {
            Console.WriteLine("Get call with body not allowed");
            throw new Exception("error in builder");
        }

        return request;
    }
}
