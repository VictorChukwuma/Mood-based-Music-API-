using Microsoft.EntityFrameworkCore;
using MoodBasedPlaylistApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MoodBasedPlaylistDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MoodBasedPlaylistDbContext")));

var app = builder.Build();
