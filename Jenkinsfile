pipeline {
  environment {
    RELEASE_ENVIRONMENT = "${params.RELEASE_ENVIRONMENT}"
  }

  agent { label 'master'
  }

  parameters {
        string (
            name : 'GIT_SSH_PATH',
            defaultValue: '',
            description: ''
        )            
            
         string (
            name : 'SOLUTIION_FILE',
            defaultValue: 'develop',
            description: ''    
        )
        string (
            name : 'NETCORE_VERSION',
            defaultValue: '',
            description: ''    
        )
        string (
            name : 'TEST_PROJECT_PATH',
            defaultValue: '',
            description: ''    
        ) 
        choice(
        name: 'RELEASE_ENVIRONMENT',
        choices: "Build\nTest",
        description: '' 
        ) 
    }
 stages {
    stage('Build') {
      when {
              expression { "${RELEASE_ENVIRONMENT}" == 'Build' }                
        }
      steps {
        sh'''
            echo '=======================Restore Project Start======================='
            dotnet${NETCORE_VERSION} restore ${SOLUTION_FILE} --source https://api.nuget.org/v3/index.json
            echo '=====================Restore Project Completed===================='

            echo '=======================Build Project Start======================='
            dotnet${NETCORE_VERSION} build ${SOLUTION_FILE} -p:Configuration=release -v:q
            echo '=====================Build Project Completed===================='
        '''
      }
    }
    stage('Test') {
       when {
              expression { "${RELEASE_ENVIRONMENT}" == 'Test' }
       }
        steps {    
            sh'''
            echo'====================Test Execution started============='
            dotnet${NETCORE_VERSION} test ${TEST_PROJECT_PATH}
            echo'====================Test Execution completed============='
            '''
        }
    }
  }
}


