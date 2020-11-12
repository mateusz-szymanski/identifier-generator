const config = require('./protractor.conf').config;

delete config.capabilities;

config.multiCapabilities = [
  {
    browserName: 'chrome',
    chromeOptions: {
      args: ['--headless', '--no-sandbox', '--disable-gpu']
    }
  },
  {
    browserName: 'firefox',
    'moz:firefoxOptions': {
      args: ['--headless']
    },
  }
]

exports.config = config;
