﻿using System;
using CampanhaBrinquedo.Domain.Entities.Campaign;
using CampanhaBrinquedo.Domain.Entities.Campaign.State;
using CampanhaBrinquedo.Domain.Entities.User;
using FluentAssertions;
using Xunit;

namespace CampanhaBrinquedo.Test.Application.Entities
{
    public class CampaignTest
    {
        private readonly User _user;

        public CampaignTest()
        {
            _user = new User("Test", "test@test.com", "123456");
        }

        [Fact]
        public void  IncreasesNumberOfChildren_()
        {
            var campaign = new Campaign(2016, "", 1);

            campaign.IncreasesNumberOfChildren();

            campaign.ChildrensQty.Should().Be(2);
        }

        [Fact]
        public void Open_Should_SwitchStateTo_Open()
        {
            var campaign = new Campaign(2016, "");

            campaign.Open(_user);

            campaign.State.Should().NotBeOfType<NotStarted>();
            campaign.State.Should().BeOfType<Open>();
        }

        [Fact]
        public void Close_Should_SwitchStateTo_Close()
        {
            var campaign = new Campaign(Guid.NewGuid(), 2016, "", 0, new Open());

            campaign.Close(_user);

            campaign.State.Should().NotBeOfType<NotStarted>();
            campaign.State.Should().NotBeOfType<Open>();
            campaign.State.Should().NotBeOfType<Reopened>();
            campaign.State.Should().BeOfType<Closed>();
        }

        [Fact]
        public void Reopen_Should_SwitchStatoTo_Reopen()
        {
            var campaign = new Campaign(Guid.NewGuid(), 2016, "", 0, new Closed());

            campaign.Reopen(_user);

            campaign.State.Should().NotBeOfType<NotStarted>();
            campaign.State.Should().NotBeOfType<Open>();
            campaign.State.Should().NotBeOfType<Closed>();
            campaign.State.Should().BeOfType<Reopened>();

        }
    }
}
