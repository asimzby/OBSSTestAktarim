Feature: ObssSite
	Obss Bot with Selenium

@tag1
Scenario: Obss Bot
	Given Obss sayfasına Girilir
	And Çerez Kabul edilir
	And Search Ikonuna Tiklanir
	And Text Alanına Automation Yazilir Ve Enter Tusuna Basilir Automation
	Then Sonuclarin Geldigi Dogrulanir
	When Cikan Sonuclardan İlkine Tiklanir
	Then Testing Autamation sayfasi oldugu dogurlanir