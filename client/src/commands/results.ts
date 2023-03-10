import { SlashCommandBuilder } from 'discord.js'

export default new SlashCommandBuilder()
  .setName('results')
  .setDescription('Fetches tournament result by given code.')
  .addStringOption(option =>
    option.setName('code')
      .setDescription('Tournament code')
      .setRequired(true),
  )
  .toJSON()
