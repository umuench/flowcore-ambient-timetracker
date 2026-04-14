using System.Net;
using System.Net.Http.Json;
using FlowCore.Contracts.Workdays;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FlowCore.Api.Tests;

public sealed class RealtimeAndAdminEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public RealtimeAndAdminEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetStatuses_ReturnsSuccess()
    {
        using var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/statuses");

        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task GetAdminLiveStatus_WithoutRole_ReturnsForbidden()
    {
        using var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/admin/live-status");

        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }

    [Fact]
    public async Task GetAdminLiveStatus_WithAdminRole_ReturnsSuccess()
    {
        using var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/admin/live-status?role=Admin");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task BroadcastPolicy_WithTeamLeadRole_ReturnsAccepted()
    {
        using var client = _factory.CreateClient();

        var response = await client.PostAsync("/api/admin/policies/broadcast?role=TeamLead&policyKey=BreakPolicy", null);

        Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
    }

    [Fact]
    public async Task ChangePresence_WithInvalidState_ReturnsBadRequest()
    {
        using var client = _factory.CreateClient();
        var request = new BookTimeRequestDto(Guid.NewGuid(), "NotAState", "note");

        var response = await client.PostAsJsonAsync("/api/presence/change", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
