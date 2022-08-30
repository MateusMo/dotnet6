﻿namespace Blog.ViewModels
{
    public class ResultViewModel<T>
    {
        public ResultViewModel(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }
        public ResultViewModel(T data)
        {
            Data = data;
        }
        public ResultViewModel(List<string> errors)
        {
            Errors = errors;
        }
        public ResultViewModel(string errors)
        {
            Errors.Add(errors);
        }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
