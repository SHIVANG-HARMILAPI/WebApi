pipeline{

    agent { label 'master' }

    parameters{

        string(

            name: "GIT_HTTPS_PATH",

            defaultValue: "https://github.com/SHIVANG-HARMILAPI/WebApi.git",

            description: "GIT HTTPS PATH"

        )

        string(

            name: "SOLUTION_PATH",

            defaultValue: "WebApi.sln",

            description: "SOLUTION_PATH"

        )

        string(

            name: "DOTNETCORE_VERSION",

            defaultValue:'' ,

            description: "Version"

        )

        string(

            name: "TEST_SOLUTION_PATH",

            defaultValue: "TestCasesForWebApi/TestCasesForWebApi.csproj",

            description: "TEST SOLUTION PATH"

        )

        

        string(

            name: "PROJECT_PATH",

            defaultValue: "WebApi/WebApi.csproj",

            description: "PROJECT PATH"

        )

        choice(

            name: "RELEASE_ENVIRONMENT",

            choices: ["Build","Test", "Publish"],

            description: "Tick what you want to do"

        )

    }

    stages{

        stage('Build'){

            when{

                expression{params.RELEASE_ENVIRONMENT == "Build" || params.RELEASE_ENVIRONMENT == "Test" || params.RELEASE_ENVIRONMENT == "Publish"}

            }

            steps{

                powershell '''

                    echo '====================Build Project Start ================'

                    dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json

                    echo '=====================Build Project Completed============'

                    echo '====================Build Project Start ================'

                    dotnet build ${PPOJECT_PATH} 

                    echo '=====================Build Project Completed============'

                '''

            }

        }

        stage('Test'){

            when{

                expression{params.RELEASE_ENVIRONMENT == "Test" || params.RELEASE_ENVIRONMENT == "Publish"}

            }

            steps{

                powershell '''

                    echo '====================Build Project Start ================'

                    dotnet test ${TEST_SOLUTION_PATH}

                    echo '=====================Build Project Completed============'

                '''

            }

        }

        stage('Publish'){

            when{

                expression{params.RELEASE_ENVIRONMENT == "Publish"}

            }

            steps{

                powershell '''

                    echo '====================Build Project Start ================'

                    dotnet publish ${PROJECT_PATH}

                    echo '=====================Build Project Completed============'

                '''

            }

        }

        stage ('push artifact') {

            when{

                expression{params.RELEASE_ENVIRONMENT == "Publish"}

            }
            steps{
                script {

                    zip zipFile: 'publish.zip', archive: true, dir: 'WebApi/bin/Debug/netcoreapp2.1'
    
                    archiveArtifacts artifacts: 'publish.zip', fingerprint: true
    
                }
            }
        }

    }

    post{

        always{

            deleteDir()

       }

    }

}
