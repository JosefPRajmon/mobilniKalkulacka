<?php
declare(strict_types=1);

namespace App\Presenters;
use Nette;

final class FeedbackPresenter extends Nette\Application\UI\Presenter {
    /** @var \App\Api\FeedbackApi @inject */
    public $fedbackApi;

    public function actionSave($title, $feedback) {
        $this->fedbackApi->save($title, $feedback);
          //  $this->redirect("this");
    }
}

?>