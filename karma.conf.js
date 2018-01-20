//jshint strict: false
module.exports = function(config) {
  config.set({

    basePath: './client',

    files: [
      { pattern: 'vendor/bower_components/angular/angular.js', included: false },
      { pattern: 'vendor/bower_components/angular-route/angular-route.js', included: false },
      { pattern: 'vendor/bower_components/angular-mocks/angular-mocks.js', included: false },
      'src/**/*.js',
    ],

    autoWatch: true,

    frameworks: ['jasmine'],

    browsers: ['Chrome'],

    plugins: [
      'karma-chrome-launcher',
      'karma-firefox-launcher',
      'karma-jasmine',
      'karma-junit-reporter',
    ],

    junitReporter: {
      outputFile: 'test_out/unit.xml',
      suite: 'unit'
    }

  });
};
